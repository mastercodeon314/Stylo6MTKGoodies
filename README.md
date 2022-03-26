# LG Stylo 6 MTK Goodies

This is a .NET wrapper around bkerler's [mtkclient](https://github.com/bkerler/mtkclient)
specifically designed for the LG Stylo 6.

This app currently supports forcing the stylo to brom mode, and bootloader unlocking the device. A carrier unlock feature is comming soon.

Install:

In order to use this tool, you must have the MTK Serial Port driver, UsbDk, and python >=3.8.
Refer to https://github.com/bkerler/mtkclient#install for further instructions.


The tool relies on a prepackaged setup that has mtkclient and SPFlash tool bundled together, i have a 7z hosted here:
https://drive.google.com/file/d/1YLitsAizcz18Tl6qXJewmRRRT8p2kOJS/view?usp=drivesdk

Download that and extract its contents to a folder named mtkclient, this folder should reside alongside Stylo6MTKGoodies.exe.
If you dowload the Release 7z from here or the github page, it will already come with this folder included.
You only need to download this separately if you are building from the source.
Usage:
After the setup is said and done, power off your Stylo 6, then open the program. 
Next, click Force Brom
Once you see this screen, plug the usb cable into the device
![image](https://user-images.githubusercontent.com/78676320/159809101-3618a1f3-8962-4615-96f1-b3059cef66ee.png)

Next you will see this:

![image](https://user-images.githubusercontent.com/78676320/159809222-4db3b2bd-bbc0-409d-bbc4-63a0f505e518.png)

Now the device is in brom mode.
Unplug the usb cable, and preform a bootloader unlock, or reboot the device.

Credits:

Huge thanks to bkerler and everyone who helped make mtkclient, the core component in this app.
Also a special thanks to warlockguitarman, who discovered the need to stall the boot sequence for mtkclient to connect.
