1. Short description.
  This driver/program is intended to "overclock" USB mice under Windows 98
  through XP x64, Windows Vista 32 bit,
  Windows Vista 64 bit (with disabled driver signature enforcement),
  Windows 7, 8, 8.1, 10 (under x64 - with Test Mode signed driver).
  Also may be used for downclocking (and downclocking shall work always).

  Note - overclocking may not work for Low speed devices which 
  controlled by non Microsoft USB stack, like USB 3.x at Windows 7
  or newest Microsoft drivers.

  Program changes only mouse rate, not touching other devices on USB.

  You can learn more about theory and the program here:
  http://www.overclockers.ru/lab/15925/Razgon_USB_myshi_ili_Software_nanosit_otvetnyj_udar.html
  (in Russian language(*))

  I have personally tested it under Windows 98SE, Windows 2000 SP2/SP4, 
  Windows XP RTM/SP1/SP2/SP3, Windows Vista 32 bit RTM, 
  Windows Vista 64 bit RTM, Windows 7 SP1 x86, Windows 7 SP1 x64,
  Windows 8 x64.
  Testing under Windows XP x64 SP1 was performed by Dark_Cloud.

2. Installation.
  1. Downclocking (all devices and drivers) or overclocking of Full Speed USB
  devices is possible always and there is no need to patch system code.

  So, if you use program for this purpose - take drivers
  from directories DRIVER\NTX86\NOPATCH\ and DRIVER\AMD64\NOPATCH\ 
  and replace drivers from directories DRIVER\NTX86\ and DRIVER\AMD64\

  Because Windows 2000 have not restrictions of overclocking Low Speed USB
  devices in system code - you can use the driver from DRIVER\NTX86\NOPATCH\
  always. Windows 98 � ME also have not such restrictions, so
  there is no patch version of driver for this OSes at all.

  2. For OSes begining from Windows XP for successful overclocking of
  Low Speed USB devices is REQUIRED the presence original (not altered
  by other programs) version of system driver USBPORT.SYS 
  (%sytemroot%\system32\drivers\usbport.sys).
  Windows 8 beginning also work with USBXHCI.SYS
  (%sytemroot%\system32\drivers\usbxhci.sys)

  3. Install my driver HIDUSBF.SYS. For this purpose execute SETUP.EXE (there
  should also be .INF and .SYS files). Click Install Service.

  In case of HIDUSBF service wasn't installed through 
  SETUP.EXE (button "Install Service") you may try to do this by OS 
  standard possibility:
  mouse right button click on HIDUSBF.INF -> Install

  If you wand to overclock mouse from Composite USB device
  - use checkbox "Process Parent". Note, there is overclocked
  all functional devices from composite device, not the mouse only.

  Then choose the line with your mouse and put a checkmark Filter On Device.
  Check that in the row Filter it says Yes. After that choose desired refresh
  rate. After that click Restart. Check if the refresh rate has really 
  changed (for example with the program Mouse Rate Checker).

  Note - under x64 version of Windows Vista and higher you must
  make HIDUSBF.SYS loadable before restarting device or overclocked device
  will stop working! In this case read carefully the section 3.3 or
  uninstall driver by disable Mice Only checkbox to view all devices
  + Restart button in SETUP.EXE.

  If your rate did not change, then you should either restart, plug out
  and plug in mouse cable or stop your mouse and restart it in 
  Device Manager.
   
  If the rate does not increase more than 125Hz, then you should 
  try DECREASE it to 31Hz or 62Hz.
  If the rate does decrease, then the driver functions properly, however
  or you mouse is not overclockable; or USBPORT.SYS/USBXHCI.SYS was altered
  or simply too new and so unknown to the program.

3. Uninstall.
  1. Unlink driver from mouse through SETUP.EXE (Filter = No)
  2. For removing a service and file of driver:
  mouse right button click on HIDUSBFU.INF -> Install
  3. If you have delete a driver but not unlink it from mouse
  then the mouse will stop working. To make mouse working you
  may simply delete device, corresponding to mouse in Device Manager,
  then scan for new devices.

4. Contacts.
  You can access newest version at this link:
  http://sweetlow.orgfree.com/download/hidusbf.zip
  
  If you can't make the program work you can contact the author - email: 
  sweetlow@tut.by

  Good luck in overclocking mice :)               SweetLow

5. History.

-------------------------------------------------------------------------------

Added 2016/03/10:

1. Improved Setup:
- generalised code of USB HID device detection (and now it works
with the Xbox 360 controllers)
- interface was made more user-friendly and foolproof
- added command line switch: /all (setup.exe /all) - allows you to set
driver for any USB device (under your personal liability)

-------------------------------------------------------------------------------

Added 2016/01/30:

1. Fixed bug in code of patching driver of USB3.0 controller (USBXHCI.SYS)
Bug can observed, for example, when USB audio device managed by USB3.0 
controller stop working.

-------------------------------------------------------------------------------

Added 2016/01/23:

1. Now Setup can install driver for Composite USB device
- use checkbox "Process Parent". Note, there is overclocked
all functional devices from composite device, not the mouse only.
For this feature functioning recompiled old drivers for Win 98&ME, 2000.

2. I was surprised to learn that some people use driver to change rate of
Full speed USB mice. So, nonpatching version of x64 driver returned to package
and such kind of using described in Installation section.

-------------------------------------------------------------------------------

Added 2016/01/02:

1. Driver now compatible with Windows 8, 8.1, 10. And both USB stacks supported:
USB2.0 (USBPORT.SYS) and USB3.0 (USBXHCI.SYS)

-------------------------------------------------------------------------------

Added 2015/04/06:

1. Much of fixing and enhancement in Setup:
  - "Restart" button now really :) work under x64; 
  - USB HID mouse detected in multifunctional devices;
  - installed filter can be undoned on nonstarting devices
    (unsigned driver at x64...) - with unchecked "Mice Only";
  - add parent device column.

-------------------------------------------------------------------------------

Added 2009/02/11:

1. Driver (patcher of USBPORT.SYS) work in Windows 7 x64 now.

-------------------------------------------------------------------------------

Added 2009/02/03:

1. To load driver under Vista x64 SP1 you can use "Test Mode" method.
See DSEO program:
http://www.ngohq.com/home.php?page=dseo

-------------------------------------------------------------------------------

Added 2008/04/22:

1. Setup now aware of Windows x64. Don't forget - under Windows Vista 64 bit
driver will load only with disabled driver signature enforcement.

-------------------------------------------------------------------------------

Added 2008/04/19:

1. Windows Vista 64 bit checked and work (with disabled driver 
signature enforcement).

-------------------------------------------------------------------------------

Added 2007/05/16:

1. Windows Vista 32 bit checked and work. In principle, version for XP x64 
may work under Vista 64 bit, however AFAIK there is required 
digitally signed driver...
2. Documentation rewritten.
3. Patched USBPORT.SYS move into separate archive.

--------------------------------------------------------------------------------

Added 2006/09/30:

1. Drivers for 98/ME and 2000 shrink to fit in one page.
2. DRIVER folder and HIDUSBF.INF reordered.

--------------------------------------------------------------------------------

Added 2006/01/12:

1. Below-mentioned development is executed for XP x64.
Thank Dark_Cloud once again for recurrent testing.

--------------------------------------------------------------------------------

Added 2005/12/26:

1. Driver was enhanced - for its installation under XP is NOT 
required to install corrected USBPORT.SYS. However, if there is observed
some anomalies - you may go back to old working sequence
(corrected USBPORT.SYS + driver in the folder DRIVER\STD).
Thank Alan 'Strider' Kivlin for the idea of patching the code 
of USBPORT.SYS on the fly.
Thank Root for valuable link for realization.
The same development for Windows XP x64 is still not done - there is a
difficulties with testing.

--------------------------------------------------------------------------------

Added 2005/08/08:

1. Translation was executed into English.
Job was done by TimFortress (email: mofey@front.ru) 2005/07/22
(*) in text above is translator additions.

2. In case of HIDUSBF service wasn't installed under Win x64 through Setup.EXE
(button "Install Service") you may try to do this by OS standard possibility:
mouse right button click on HIDUSBF.INF -> Install

3. There was added possibility to uninstall HIDUSBF service and file:
mouse right button click on HIDUSBFU.INF -> Install

--------------------------------------------------------------------------------

Added 2005/05/31:
Written documentation (in Russian).

--------------------------------------------------------------------------------

Added 2005/04/10:
Developed driver for Windows XP x64. Tested by Dark_Cloud.

--------------------------------------------------------------------------------

Added 2005/01/19:
Written GUI installer - SETUP.EXE

--------------------------------------------------------------------------------

2004/12/28:
Initial version, presented in article on overclockers.ru

--------------------------------------------------------------------------------
