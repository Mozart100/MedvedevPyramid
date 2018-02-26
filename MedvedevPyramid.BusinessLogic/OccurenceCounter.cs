using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedvedevPyramid.BusinessLogic
{
    public class Report
    {
        public int Sum { get; set; }
        public int Frequence { get; set; }
    }

    public class OccurenceCounter
    {
        private Dictionary<int, Report> _reports;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public OccurenceCounter()
        {
            _reports = new Dictionary<int, Report>();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public IEnumerable<Report> VerifyOccurences(PlainItem root)
        {
            Analyze(root);


            return _reports.Values;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------

        private void Analyze(PlainItem root, int sum = 0)
        {
            if (root.HasChildren() == false)
            {
                var totalSum = sum + root.Item;
                if (_reports.ContainsKey(totalSum) == false)
                {
                    _reports[totalSum] = new Report { Frequence = 1, Sum = totalSum };
                }
                else
                {
                    _reports[totalSum].Frequence++;
                }

                return;
            }

            Analyze(root.Left, sum + root.Item);
            Analyze(root.Right, sum + root.Item);

        }

    }
}
