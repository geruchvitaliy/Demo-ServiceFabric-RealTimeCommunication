using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Models.Device
{
    public class StatusDto
    {
        public DeviceId DeviceId { get; set; }

        public Location LastLocation { get; set; }

        public DateTime LastCommunicationDate { get; set; }

        public double LastCommunicationElapsedTime { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Error,
        Warning,
        Ok
    }

    public static class StatusDtoExtensions
    {
        public static IEnumerable<StatusDto> ToStatusDto(this IEnumerable<StatusDetails> details) =>
            details?.Select(x => x.ToStatusDto());

        public static StatusDto ToStatusDto(this StatusDetails details)
        {
            return new StatusDto
            {
                DeviceId = details.DeviceId,
                LastCommunicationDate = details.LastCommunicationDate,
                LastCommunicationElapsedTime = Math.Round((DateTime.UtcNow - details.LastCommunicationDate).TotalMinutes, 2),
                LastLocation = details.LastLocation,
                Status = details.ToStatus()
            };
        }

        public static Status ToStatus(this StatusDetails details) =>
            details.LastCommunicationDate.ToStatus();

        public static Status ToStatus(this DateTime date)
        {
            if (date > DateTime.UtcNow.AddHours(-12))
                return Status.Ok;
            else if (date <= DateTime.UtcNow.AddHours(-12) && date > DateTime.UtcNow.AddHours(-24))
                return Status.Warning;
            else
                return Status.Error;
        }
    }
}