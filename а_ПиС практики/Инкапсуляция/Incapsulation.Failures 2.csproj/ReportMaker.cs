using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{
    public class ReportMaker
    {
        public static List<string> FindDevicesFailedBeforeDate(DateTime date, List<Failure> failures, List<Device> devices)
        {
            var result = new List<string>();
            for (int i = 0; i < failures.Count; i++)
                if (failures[i].IsSerious && failures[i].expiryTime < date) result.Add(devices[i].name);
            return result;
        }

        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,

            int[] failureTypes, 
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> dict) 
        {
            DateTime date = new DateTime(year, month, day);
            List<Failure> failures = new List<Failure>();
            List<Device> devices = new List<Device>();
            for (int i = 0; i < failureTypes.Length; i++)
            {
                failures.Add(new Failure((FailureType)failureTypes[i], 
                    new DateTime((int)times[i][2], (int)times[i][1], (int)times[i][0])));
                devices.Add(new Device((int)dict[i]["DeviceId"], (string)dict[i]["Name"]));
            }
            return FindDevicesFailedBeforeDate(date, failures, devices);
        }
    }

    public class Failure
    {
        public readonly FailureType failureType;
        public readonly DateTime expiryTime;

        public Failure(FailureType failureType, DateTime expiryTime)
        {
            this.failureType = failureType;
            this.expiryTime = expiryTime;
        }

        public bool IsSerious
        {
            get
            {
                return failureType == FailureType.UnexpectedShutdown 
                    || failureType == FailureType.HardwareFailures;
            }
        }
    }
    public class Device
    {
        public readonly int id;
        public readonly string name;

        public Device(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
    public enum FailureType
    {
        UnexpectedShutdown,
        ShortNonResponding,
        HardwareFailures,
        ConnectionProblems
    }
}
