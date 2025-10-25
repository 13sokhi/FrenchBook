FrenchBook is a Language Learning App designed to help the learning process

It helps users by:
1. Enabling them to create multiple Topics
2. Translate sentences and paragraphs from English to French for each Topic
3. Save the translations
4. Listen to pronunciations

Steps to try this tool:
1. Create a Python venv using Python 3.11
2. Run commands - "pip install libretranslate" and then "libretranslate --load-only en,fr"
3. Copy this C# repository
4. Change MySQL login credentials in FrenchBookContext.cs file to your credentials
5. In your Windows Settings, add French (France) in both - (1) Time & Language > Language & Region, (2) Time & Language > Speech

Notes:
1. Python commands are used to locally host the open-source translation service
2. French (France) is required to be installed because the App uses System voices for Text-To-Speech functionality
