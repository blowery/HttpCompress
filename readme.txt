== Version History ==
6.0, V2 -----
  Changes:
    - Compiled against v2 of the .NET framework, using the framework supplied GZip
      and Deflate streams.  This rev requires .NET2 and does not use #ziplib.
      
6.0 ---------
  Changes:
    - I now delay the insertion of the compression header until the first
      write is attempted on the compressing stream.  This allows exceptions
      to be written properly, though they will be written uncompressed.  
    - The same fix should allow Server.Transfer and friends to work without
      modification, though the contents of pages written using Server.Transfer
      will not be compressed.
    - Thanks to Milan Negovan for helping me track down this issue and thanks
      to the shower for helping me come up with a general solution.

5.0.0.0 -----
  Changes:
    - All these came from outside sources.  No real work from me.
    - Added support for the VaryByHeader, thanks to Simon Fell and Ian Anderson
    - Reworked the filter picker (all thanks to Ian Anderson)
      - No filter is added if the compression level is set to None
      - Fixed a bug where the INSTALLED_TAG was not being set into the 
        Context properly if compression was determined unnecessary.

4.0.0.0 -----
  Changes:
    - upped to version 4.  From now on, every release will be a major 
      version release.
    - now have support for path-based and ContentType-based exlusions
    - now using a slightly custom edition of #zlib 0.5 to fix a couple bugs
    - better method for sinking asp.net pipeline events
    - modified all namespaces to blowery.Web.HttpCompress
    - added custom response header (X-Compressed-By)
    - the assembly is now blowery.Web.HttpCompress
    - the config section handler is now blowery.Web.HttpCompress.SectionHandler
    - the config section is now httpCompress, in keeping with the new naming
      - you will have to update your configuration files for this release!
    - fixed a bug where i was improperly detecting the supported compression
      types sent by the browser.  I would only read in the first one.
    


1.1 ---------

  MAJOR CHANGES THAT WILL AFFECT YOU
    - the assembly is now named HttpCompressionModule.dll
    - the config section handler is now HttpCompressionModuleSectionHandler
    - YOU WILL NEED TO UPDATE YOUR CONFIG FILES
      FOR THIS VERSION TO WORK (see samples for direction)
  
  Other stuff
    - moved to SharpZipLib (formerly NZipLib) 0.31 which
      contains a bunch of bug fixes.  This means I just
      inherited a bunch of bug fixes.  yay!
    - updated the code to use the new ICSharpCode namespace
    - reworked the way the configuration works
      - no more generic http modules.  i'm only writing this
        one, so this made the code simpler
      - removed the Unspecified flag on the Enums.  Not needed.
        now, it defaults to Deflate + Normal
      - decided to not support config parenting, as it doesn't
        really make sense for this
    - pulled out some trace stuff from the DEBUG version that
      didn't need to be there
    - actually shipping compiled versions, both DEBUG and RELEASE
    - added examples.  
    

1.0 ---------
  - initial introduction

=== Introduction ==
Hey there,

Thanks for downloading my compressing filter for ASP.NET!  As
you can see, the full source is provided so you can 
understand how it works and modify it if you want.

If you don't have visual studio, no fear.  The whole project
lives in one directory, so csc *.cs should work, you just need
to add a reference to the supplied SharpZipLib.dll.

For instructions on how to slip the HttpCompressionModule in,
see the provided example.  It shows what entries have
to be added to the web.config to set things up.

So, to get things going, here's what you have to do:
1) compile the project into a library (or just use the
     version in /lib)
2) move the .dll that comes from compilation to the /bin directory of
   your asp.net web app
3) add the entries to the web.config of your asp.net app

That's it.  That should get you going.



--b