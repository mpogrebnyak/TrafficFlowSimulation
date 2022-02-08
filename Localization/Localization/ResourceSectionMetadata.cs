using System;
using System.Collections.Generic;

namespace Localization.Localization
{
	public class ResourceSectionMetadata: ResourceMetadata
	{
		public ResourceSectionMetadata()
		{
			Children = new List<ResourceMetadata>();
		}

		public Type Type { get; set; }

		public IList<ResourceMetadata> Children { get; private set; }
	}
}
