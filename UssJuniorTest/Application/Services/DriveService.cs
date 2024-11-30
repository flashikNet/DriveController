using System;
using UssJuniorTest.Application.Interfaces;
using UssJuniorTest.Application.Models.Requests;
using UssJuniorTest.Application.Models.Responses;
using UssJuniorTest.Core;
using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Application.Services
{
    public class DriveService : IDriveService
    {
        private IRepository<Car> carRepository;
        private IRepository<Person> personRepository;
        private IRepository<DriveLog> driveLogRepository;
        public DriveService(IRepository<Car> carRepo, IRepository<Person> personRepo, IRepository<DriveLog> driveLogRepo)
        {
            carRepository = carRepo;
            personRepository = personRepo;
            driveLogRepository = driveLogRepo;
        }
        public GetDrivesRes[] GetDrives(GetDrivesReq req)
        {
            var res = from driveLog in driveLogRepository.GetAll()
                      where req.Start < driveLog.EndDateTime && req.End > driveLog.StartDateTime
                      join person in personRepository.GetAll() on driveLog.PersonId equals person.Id
                      join car in carRepository.GetAll() on driveLog.CarId equals car.Id
                      select new GetDrivesRes
                      {
                          Name = person.Name,
                          Age = person.Age,
                          Manufacturer = car.Manufacturer,
                          Model = car.Model,
                          Days = (Min(req.End, driveLog.EndDateTime) - Max(req.Start, driveLog.StartDateTime)).Days,
                          Hours = (Min(req.End, driveLog.EndDateTime) - Max(req.Start, driveLog.StartDateTime)).Hours,
                          Minutes = (Min(req.End, driveLog.EndDateTime) - Max(req.Start, driveLog.StartDateTime)).Minutes
                      };
            return res.ToArray();
        }

        private DateTime Max(DateTime dt1, DateTime dt2)
        {
            if (dt1.CompareTo(dt2) > 0)
            {
                return dt1;
            }
            return dt2;
        }

        private DateTime Min(DateTime dt1, DateTime dt2)
        {
            if (dt1.CompareTo(dt2) < 0)
            {
                return dt1;
            }
            return dt2;
        }
    }
}
