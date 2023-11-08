using Moq;
using Payments.Api.Integration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Api.Tests
{
    internal class MockConfig
    {
        public Mock<IPaymentsRepository> PaymentsRepository { get; }

        internal MockConfig()
        {
            this.PaymentsRepository = new Mock<IPaymentsRepository>();
        }

        public IEnumerable<(Type, object)> GetMocks()
        {
            return GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x =>
                {
                    var underlyingType = x.PropertyType.GetGenericArguments()[0];
                    var value = x.GetValue(this) as Mock;

                    return (underlyingType, value.Object);
                })
                .ToArray();
        }
    }
}
