using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using AutoFixture.Kernel;
using Eisk.Core.Utils;

namespace Eisk.Test.Core.DataGen
{
    public class StringAttributeAggregatedRelay : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {

#pragma warning disable 618
            object result = new NoSpecimen();
#pragma warning restore 618

            var pi = request as PropertyInfo;

            if (pi != null)
            {
                if (pi.PropertyType == typeof(string))
                {
                    if (Attribute.IsDefined(pi, typeof(StringLengthAttribute)))
                    {
                        var stringLengthAttribute = ((ICustomAttributeProvider)request).
                            GetCustomAttributes(typeof(StringLengthAttribute), true)
                            .Cast<StringLengthAttribute>().Single();

                        return Attribute.IsDefined(pi, typeof(UrlAttribute)) || Attribute.IsDefined(pi, typeof(UriAttribute))
                            ? GetGeneratedUri(context, stringLengthAttribute.MinimumLength,
                                stringLengthAttribute.MaximumLength)
                            : context.Resolve(new ConstrainedStringRequest(
                                stringLengthAttribute.MinimumLength,
                                stringLengthAttribute.MaximumLength));
                    }

                    if (Attribute.IsDefined(pi, typeof(UrlAttribute)))
                    {
                        return GetGeneratedUri(context);
                    }
                }

                return result;
            }

            return result;
        }

        private string GetGeneratedUri(ISpecimenContext context, int minLength = 1, int maxLength = int.MaxValue)
        {
            var generatedUri = new DomainUriGenerator(minLength, maxLength)
                .Create(typeof(Uri), context);
            return generatedUri.ToString();
        }

    }
}