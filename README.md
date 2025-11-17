FrenchBook is a Language Learning App designed to help the learning process

It helps users by:
1. Enabling them to create multiple Topics
2. Translate sentences and paragraphs from English to French for each Topic
3. Save the translations
4. Listen to pronunciations

Pre-requisites to try this tool (Need to be done once):
1. Create a Python venv using Python 3.11 using CMD
2. In that venv made using CMD run command - "pip install libretranslate". This will install open-source translation API locally
3. Make new WPF app in Visual Studio and clone this C# repository. Then open the .sln file
4. Change MySQL login credentials in FrenchBookContext.cs file to your credentials
5. In your Windows Settings, add French (France) in both - (1) Time & Language > Language & Region, (2) Time & Language > Speech

Steps to run the tool (Need to be done everytime to run the APP):
1. Activate the Python venv using CMD created as a pre-requisite
2. Run command - "libretranslate --load-only en,fr". This will run the translation server locally in CMD window
3. Run the WPF app

Notes:
1. Python commands are used to locally host the open-source translation service
2. French (France) is required to be installed because the App uses System voices for Text-To-Speech functionality
3. Python venv can be made and activated using CMD commands. A folder is made that contains this venv (Google details on commands to create venv)
