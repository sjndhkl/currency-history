using System;
using System.Collections.Generic;

namespace App.CurrencyHistory.Common.Requests
{
    public class CurrencyHistoryRequest
    {
        private string _base = "AUD";
        public string Base {
            get => _base;
            set
            {
                _base = value.ToUpper();
            }
        }
        private string _target = "NOK";
        public string Target
        {
            get => _target;
            set
            {
                _target = value.ToUpper();
            }
        }


        private List<string> _dateList;
        public List<string> DateList {
            get {
                if(_dateList == null)
                {
                    _dateList = new List<string>
                    {
                        _dates
                    };
                }
                return _dateList;
            }
            set => _dateList = value;
        }

        private string _dates = "2014-04-03";
        public string Dates {
            get => _dates;
            set {
                _dates = value;
                DateList = new List<string>(_dates.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));
            }
        }
    }
}
