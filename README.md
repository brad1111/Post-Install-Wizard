# Post-Install-Wizard
A wizard used after a MDT install to replace the OOBE.

NOTES:
1. Requires setup first to be able to use in your environment (See SETUP)
2. Currently requires MDT, WSUS and a closed source msi installer for all functions. (MSI Installer not redistributed so will require you to remove/edit this feature as required)
3. Uninstallation function does not work unless you own closed source software.

SETUP:
1. Open Solution in VS 2015
2. Under Post-Install-Wizard,Properties Click resources.
3. Change all of the resources to work in your environment. (Not all required, but recommended)
