using Algorithm.BaseAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.StrategyModel
{
    //适配器这里放两种模式()
    public class SortAdapter : ISortAlgorithm
    {
        public SortAdapter(IPXAlgorithm pXAlgorithm)
        {
            _pXAlgorithm = pXAlgorithm;
        }
        protected IPXAlgorithm _pXAlgorithm;
        public void SortNum()
        {
            _pXAlgorithm.PXSum();
        }
    }

    public abstract class Cehes
    {
        public void GetData()
        {

        }
    }
    public interface cess
    {
       

    }
}
