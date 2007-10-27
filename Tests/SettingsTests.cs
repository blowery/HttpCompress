using System;
using System.Diagnostics;
using System.Resources;
using NUnit.Framework;

using blowery.Web.HttpCompress;

namespace blowery.Web.HttpCompress.Tests {
  /// <summary>
  /// Tests for the <see cref="Settings"/> class
  /// </summary>
  [TestFixture]
  public class SettingsTests {
    
    ResourceManager rman;

    [SetUp] public void Setup() {
      rman = Utility.GetResourceManager("XmlTestDocuments");
    }

    [Test] public void DefaultTest() {
      Assertion.AssertEquals(CompressionLevels.Default, Settings.Default.CompressionLevel);
      Assertion.AssertEquals(Algorithms.Default, Settings.Default.PreferredAlgorithm);
    }

    [Test] public void EmptyNodeTest() {
      Settings setting = new Settings(MakeNode(rman.GetString("EmptyNode")));
      Assertion.AssertEquals(CompressionLevels.Default, setting.CompressionLevel);
      Assertion.AssertEquals(Algorithms.Default, setting.PreferredAlgorithm);
    }

    [Test] public void DeflateTest() {
      Settings setting = new Settings(MakeNode(rman.GetString("Deflate")));
      Assertion.AssertEquals(Algorithms.Deflate, setting.PreferredAlgorithm);
      Assertion.AssertEquals(CompressionLevels.Default, setting.CompressionLevel);
    }

    [Test] public void GZipTest() {
      Settings setting = new Settings(MakeNode(rman.GetString("GZip")));
      Assertion.AssertEquals(Algorithms.GZip, setting.PreferredAlgorithm);
      Assertion.AssertEquals(CompressionLevels.Default, setting.CompressionLevel);
    }

    [Test] public void HighLevelTest() {
      Settings setting = new Settings(MakeNode(rman.GetString("LevelHigh")));
      Assertion.AssertEquals(Algorithms.Default, setting.PreferredAlgorithm);
      Assertion.AssertEquals(CompressionLevels.High, setting.CompressionLevel);
    }

    [Test] public void NormalLevelTest() {
      Settings setting = new Settings(MakeNode(rman.GetString("LevelNormal")));
      Assertion.AssertEquals(Algorithms.Default, setting.PreferredAlgorithm);
      Assertion.AssertEquals(CompressionLevels.Normal, setting.CompressionLevel);
    }

    [Test] public void LowLevelTest() {
      Settings setting = new Settings(MakeNode(rman.GetString("LevelLow")));
      Assertion.AssertEquals(Algorithms.Default, setting.PreferredAlgorithm);
      Assertion.AssertEquals(CompressionLevels.Low, setting.CompressionLevel);
    }

    [Test] public void BadLevelTest() {
      Settings setting = new Settings(MakeNode(rman.GetString("BadLevel")));
      Assertion.AssertEquals(CompressionLevels.Default, setting.CompressionLevel);
    }

    [Test] public void BadAlgorithmTest() {
      Settings setting = new Settings(MakeNode(rman.GetString("BadAlgorithm")));
      Assertion.AssertEquals(Algorithms.Default, setting.PreferredAlgorithm);
    }

    [Test]
    public void AddSettingsTests() {
      Settings setting = new Settings(MakeNode(rman.GetString("DeflateAndHigh")));
      Assertion.AssertEquals(CompressionLevels.High, setting.CompressionLevel);
      Assertion.AssertEquals(Algorithms.Deflate, setting.PreferredAlgorithm);

      // test adding a null node
      setting.AddSettings(null);
      Assertion.AssertEquals(CompressionLevels.High, setting.CompressionLevel);
      Assertion.AssertEquals(Algorithms.Deflate, setting.PreferredAlgorithm);

      // test overriding algorithm
      setting.AddSettings(MakeNode(rman.GetString("GZip")));
      Assertion.AssertEquals(CompressionLevels.High, setting.CompressionLevel);
      Assertion.AssertEquals(Algorithms.GZip, setting.PreferredAlgorithm);

      // test overriding compression level
      setting.AddSettings(MakeNode(rman.GetString("LevelLow")));
      Assertion.AssertEquals(CompressionLevels.Low, setting.CompressionLevel);
      Assertion.AssertEquals(Algorithms.GZip, setting.PreferredAlgorithm);

    }

    [Test] public void UserAddedExcludedType() {
      Settings setting = new Settings(MakeNode(rman.GetString("ExcludeBenFoo")));
      Assertion.Assert(setting.IsExcludedMimeType("ben/foo"));
    }

    [Test] public void UserAddedMultipleExcludedTypes() {
      Settings setting = new Settings(MakeNode(rman.GetString("ExcludeMultipleTypes")));
      Assertion.Assert(setting.IsExcludedMimeType("ben/foo"));
      Assertion.Assert(setting.IsExcludedMimeType("image/jpeg"));
    }

    [Test] public void UserAddedAndRemovedType() {
      Settings setting = new Settings(MakeNode(rman.GetString("AddAndRemoveSameType")));
      Assertion.Assert(!setting.IsExcludedMimeType("user/silly"));
    }

    [Test] public void UserRemovedExcludedType() {
      Settings setting = new Settings(MakeNode(rman.GetString("ExcludeMultipleTypes")));
      Assertion.Assert(setting.IsExcludedMimeType("ben/foo"));
      Assertion.Assert(setting.IsExcludedMimeType("image/jpeg"));

      setting.AddSettings(MakeNode(rman.GetString("RemoveImageJpegExclusion")));
      Assertion.Assert(setting.IsExcludedMimeType("ben/foo"));
      Assertion.Assert(!setting.IsExcludedMimeType("image/jpeg"));
    }

    [Test] public void ChildAddsMimeExclude(){
      Settings parent = Settings.Default;
      parent.AddSettings(MakeNode(rman.GetString("ExcludeBenFoo")));
      Assertion.Assert(parent.IsExcludedMimeType("ben/foo"));
    }

    [Test] public void ExcludeMultiplePaths() {
      Settings setting = new Settings(MakeNode(rman.GetString("ExcludeMultiplePaths")));
      Assertion.Assert(setting.IsExcludedPath("foo.aspx"));
      Assertion.Assert(setting.IsExcludedPath("foo/bar.aspx"));
    }

    [Test] public void RemoveExistingPathExclude() {
      Settings setting = new Settings(MakeNode(rman.GetString("ExcludeMultiplePaths")));
      setting.AddSettings(MakeNode(rman.GetString("RemoveFooAspxExclude")));
      Assertion.Assert(!setting.IsExcludedPath("foo.aspx"));
      Assertion.Assert(setting.IsExcludedPath("foo/bar.aspx"));
    }

    private System.Xml.XmlNode MakeNode(string xml) {
      System.Xml.XmlDocument dom = new System.Xml.XmlDocument();
      dom.LoadXml(xml);
      return dom.DocumentElement;
    }
  }
}
