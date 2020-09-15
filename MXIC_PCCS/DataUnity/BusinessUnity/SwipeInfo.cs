using MXIC_PCCS.DataUnity.Interface;
using MXIC_PCCS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MXIC_PCCS.DataUnity.BusinessUnity
{
    public class SwipeInfo : ISwipeInfo, IDisposable
    {
        public MXIC_PCCSContext _db = new MXIC_PCCSContext();



        //關閉資料庫
        public void Dispose()
        {
            ((IDisposable)_db).Dispose();
        }
        public string CheckinList(string VendorName, string EmpID, string EmpName, DateTime? StartTime, DateTime? EndTime,string AttendTypeSelect)
        {
            var _List = _db.MXIC_View_Swipes.Select(x=>new { x.PoNo ,x.VendorName ,x.EmpID ,x.EmpName ,x.SwipeTime ,x.EditID ,x.AttendType});

            if (!string.IsNullOrWhiteSpace(VendorName))
            {
                _List = _List.Where(x => x.VendorName.ToLower().Contains(VendorName.ToLower()));

            }

            if (!string.IsNullOrWhiteSpace(EmpID))
            {
                _List = _List.Where(x => x.EmpID.ToLower().Contains(EmpID.ToLower()));

            }

            if (!string.IsNullOrWhiteSpace(EmpName))
            {
                _List = _List.Where(x => x.EmpName.ToLower().Contains(EmpName.ToLower()));

            }

            if (!string.IsNullOrWhiteSpace(StartTime.ToString()) && !string.IsNullOrWhiteSpace(EndTime.ToString()))
            {

                _List = _List.Where(x => x.SwipeTime >= StartTime && x.SwipeTime <= EndTime);

            }

            if (!string.IsNullOrWhiteSpace(AttendTypeSelect))
            {
                _List = _List.Where(x => x.AttendType== AttendTypeSelect);

            }

            string Str = JsonConvert.SerializeObject(_List, Formatting.Indented);


            return (Str);
        }
    }
}