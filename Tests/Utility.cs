using System;
using System.Resources;

namespace blowery.Web.HttpCompress.Tests {
  /// <summary>Some utility functions for the tests</summary>
  sealed class Utility {
    private Utility() { }

    public static System.Resources.ResourceManager GetResourceManager(string nameOfResouce) {
      return new ResourceManager(Constants.Namespace + "." + nameOfResouce, System.Reflection.Assembly.GetExecutingAssembly());
    }
  }
}
