using Converter;
using UnityEngine;

namespace Tests.EditMode.Stubs
{
    public class StubLog : IResource
    {
        public int ProductAmount { get; }


        public StubLog()
        {
            ProductAmount = 1;
        }


        public StubLog(int productAmount)
        {
            ProductAmount = Mathf.Clamp(productAmount, 1, int.MaxValue);
        }
    }
}