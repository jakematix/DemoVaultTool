# Demo Vault Tool for M-Files - Partner Version
This the Demo Vault Tool that is used as the utility application in M-Files Demo Environment (implemented as Windows Hyper-V Virtual Machine running Windows 10) to manage M-Files demo vaults and environment.

The tool is implemented using C# and .NET. M-Files specific implementation is based on the usage of M-Files API.

## Functionalities
* Adding and removing M-Files vaults
* Access to documentation and helper documents that are stored in Azure File Share
* Downloading new vaults from the Vault Repository from Azure Blob
* Creation and removing of connections to demo vaults
* Making backups and copies from the vaults
* Adding, updating and removing of vault applications (vault applications are stored in the Repository in Azure Blob)
* Managing the licenses for M-Files server and vault applications
* Managing of M-Files updates
* Managing of Windows updates (automatic updates are restricted in the Demo Environment)
* Changing of locales and country based variables of the demo environment Windows. Available localizations are United States, Finland, France, Germany, Sweden, United Kingdom

## Some screenshots from the Tool

### Main window

![Main Window of the Demo Vault Tool](/Images/DemoVaultToolMainWindow.png)

### Vault Connection Manager
![Vault Connection Manager](/Images/Connections.png)

### Vault Library Manager
![Vault Library Manager](/Images/VaultLibraryAccess.png)

## Running environment aka. Demo Environment

Running environment is Hyper-V Virtual Machine. Windows 10 is optimized to contain only necessary features and is equipped with all the tools needed to give demos. Image size is appr. 80 GB. Minimum RAM amount needed for smooth operating experience is 8 GB which is configured as the static startup memory to shorten the startup time.

![Demo Environment Hyper-V Virtual Machine](/Images/DemoEnvironmentHyperV.png)