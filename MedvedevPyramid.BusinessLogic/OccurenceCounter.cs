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
        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public OccurenceCounter()
        {
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public IEnumerable<Report> CountOccurences(PlainItem root)
        {
            var reports = new Dictionary<int, Report>();
            Analyze(root, reports);


            return reports.Values.OrderByDescending(x => x.Frequence);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        private void Analyze(PlainItem root, Dictionary<int, Report> reports, int sum = 0)
        {
            if (root.HasChildren() == false)
            {
                var totalSum = sum + root.Item;
                if (reports.ContainsKey(totalSum) == false)
                {
                    reports[totalSum] = new Report { Frequence = 1, Sum = totalSum };
                }
                else
                {
                    reports[totalSum].Frequence++;
                }

                return;
            }

            Analyze(root.Left, reports, sum + root.Item);
            Analyze(root.Right, reports,sum + root.Item);

        }

    }
}
