using System;

namespace UberEats.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public string ResourceName { get; }
        public string ResourceIdentifier { get; }

        public NotFoundException(string resourceName, string resourceIdentifier)
            : base($"A {resourceName} with id: {resourceIdentifier} does not exist")
        {
            ResourceName = resourceName;
            ResourceIdentifier = resourceIdentifier;
        }
    }
}
