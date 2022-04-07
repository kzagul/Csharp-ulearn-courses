using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{

    public class Common
    {
        //public static bool IsFailureSerious(Failure failureType)
        //{
        //    if (failureType == Failure.UnexpectedShutdown
        //        || failureType == Failure.HardwareFailures)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public static bool Earlier(DateTime first, DateTime second)
        //{
        //    return first < second;
        //}


        //public static Device CheckDeviceId(Device[] devices, int id)
        //{
        //    for (int i = 0; i < devices.Length; i++)
        //        if (devices[i].id == id)
        //            return devices[i];
        //    return null;
        //}

        //public static Failure FailureByIndex(int index)
        //{
        //    if (index == 0) return Failure.UnexpectedShutdown;
        //    if (index == 1) return Failure.ShortNonResponding;
        //    if (index == 2) return Failure.HardwareFailures;
        //    return Failure.ConnectionProblems;
        //}

        // - потом убрать это

        //public static int Earlier(object[] v, int day, int month, int year)
        //{
        //    int vYear = (int)v[2];
        //    int vMonth = (int)v[1];
        //    int vDay = (int)v[0];
        //    if (vYear < year) return 1;
        //    if (vYear > year) return 0;
        //    if (vMonth < month) return 1;
        //    if (vMonth > month) return 0;
        //    if (vDay < day) return 1;
        //    return 0;
        //}


    }

    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        ///

        public static List<string> FindDevicesFailedBeforeDate(DateTime date, List<Failure> failures, List<Device> devices)
        {
            var result = new List<string>();
            for (int i = 0; i < failures.Count; i++)
                if (failures[i].IsSerious && failures[i].expiryTime < date) result.Add(devices[i].name);
            return result;
        }


        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,// это 
            int month,// это 
            int year,//и это можно объединить в одно

            int[] failureTypes, // тип отказа (из-за чего)
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> dict) // список девайсов
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

    //девайс - сделано
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
