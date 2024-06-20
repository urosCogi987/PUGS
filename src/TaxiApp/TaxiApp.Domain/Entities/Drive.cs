﻿using TaxiApp.Domain.DomainEvents;
using TaxiApp.Domain.Entities.Enum;

namespace TaxiApp.Domain.Entities
{
    public sealed class Drive : BaseEntity
    {
        private Drive(Guid id, Guid userId, string fromAddress, string toAddress, 
                      DriveStatus status, int distance, int driveTime, double price) : base(id)
        {            
            UserId = userId;
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Distance = distance;
            DriveTime = driveTime;
            Price = price;
            Status = status;
            CreatedOn = DateTime.UtcNow;
        }

        public Guid UserId { get; private set; }
        public User User { get; set; }
        public Guid? DriverId { get; private set; }
        public User? Driver { get; set; }
        public string FromAddress { get; private set; }        
        public string ToAddress { get; private set; }        
        public int DriveTime { get; private set; }
        public int DriverArrivingTime { get; private set; }
        public int Distance { get; private set; }
        public double Price { get; set; }
        public DriveStatus Status { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public void AcceptDrive(Guid driverId, int driverArrivingTime)
        {
            DriverId = driverId;
            DriverArrivingTime = driverArrivingTime;
            Status = DriveStatus.DriverConfirmed;            
            RaiseDomainEvent(new DriveAcceptedDomainEvent(Guid.NewGuid(), UserId, driverId));
        }            

        public static Drive Create(Guid id, Guid userId, string fromAddress, string toAddress, 
                                   DriveStatus status, int distance, int driveTime, double price)
            => new Drive(id, userId, fromAddress, toAddress, status, distance, driveTime, price);
    }
}