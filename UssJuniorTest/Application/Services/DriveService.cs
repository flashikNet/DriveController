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
            //Console.WriteLine(driveLogRepository.GetAll().First().EndDateTime - driveLogRepository.GetAll().First().StartDateTime);
            //var res = driveLogRepository.GetAll().Join(carRepository.GetAll(),
            //    d => d.CarId, c => c.Id,
            //    (d, c) => new
            //    {
            //        PersonId = d.PersonId,
            //        StartDateTime = d.StartDateTime,
            //        EndDateTime = d.EndDateTime,
            //        Manufacturer = c.Manufacturer,
            //        Model = c.Model,
            //    })
            //    .Join(personRepository.GetAll(),
            //    d => d.PersonId,
            //    p => p.Id,
            //    (d, person) => new GetDrivesRes
            //    {
            //        Name = person.Name,
            //        Age = person.Age,
            //        Manufacturer = d.Manufacturer,
            //        Model = d.Model,
            //        Days = (Min(req.End, d.EndDateTime) - Max(req.Start, d.StartDateTime)).Days,
            //        Hours = (Min(req.End, d.EndDateTime) - Max(req.Start, d.StartDateTime)).Hours,
            //        Minutes = (Min(req.End, d.EndDateTime) - Max(req.Start, d.StartDateTime)).Minutes

            //    });
            var res = from driveLog in driveLogRepository.GetAll()
                      where driveLog.StartDateTime.CompareTo(req.Start) >= 0 || driveLog.EndDateTime.CompareTo(req.End) <= 0
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
            if(dt1.CompareTo(dt2) > 0) return dt1;
            return dt2;
        }

        private DateTime Min(DateTime dt1, DateTime dt2)
        {
            if (dt1.CompareTo(dt2)<0) return dt1;
            return dt2;
        }
    }
}
