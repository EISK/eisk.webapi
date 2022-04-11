using System;
using AutoFixture;
using AutoFixture.Kernel;

namespace Eisk.Test.Core.DataGen
{
    /// <summary>
    /// Creates new <see cref="Uri"/> instances.
    /// </summary>
    public class DomainUriGenerator
    {
        private readonly int _minSize, _maxSize;
        private readonly bool _appendPath;

        public DomainUriGenerator(int minSize = 1, int maxSize = int.MaxValue, bool appendPath = true)
        {
            _minSize = minSize;
            _maxSize = maxSize;
            _appendPath = appendPath;
        }

        /// <summary>
        /// Creates a new specimen based on a request.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A context that can be used to create other specimens.</param>
        /// <returns>
        /// The requested specimen if possible; otherwise a <see cref="NoSpecimen"/> instance.
        /// </returns>
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!typeof (Uri).Equals(request))
            {
#pragma warning disable 618
                return new NoSpecimen();
#pragma warning restore 618
            }

            var scheme = context.Resolve(typeof (UriScheme)) as UriScheme;
            if (scheme == null)
            {
#pragma warning disable 618
                return new NoSpecimen();
#pragma warning restore 618
            }

            return CreateUri(scheme, context);
        }

        private Uri CreateUri(UriScheme scheme, ISpecimenContext context)
        {
            string suffix = string.Empty;

            ConstrainedStringRequest constrainedStringRequest = new ConstrainedStringRequest(_minSize, _maxSize);

            if (_appendPath)
                suffix = "/" + context.Resolve(constrainedStringRequest);

            return new Uri(scheme + "://google.com/" + suffix);//TODO: support maxsize constraint
        }
    }
}