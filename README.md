# sort-lines-in-files
First, the program creates all the folders [a-z0-9] and inside of them creates more folders like [a-zA-Z0-9][a-z0-9].
![alt text](https://github.com/JBUinfo/sort-lines-in-files/blob/master/Images/CreateFolders.png?raw=true)


Second, the program creates all the files [a-z0-9][a-zA-Z0-9][a-z0-9] inside the subfolders.
![alt text](https://github.com/JBUinfo/sort-lines-in-files/blob/master/Images/CreateFiles.png?raw=true)


Third, reads each line of all the files inside a folder (recursive) and classify them inside the files that has been created before.
  To clasify them, catch the first 3 characters of each line.
![alt text](https://github.com/JBUinfo/sort-lines-in-files/blob/master/Images/SortLines.png?raw=true)


If there is any character different from [a-zA-Z0-9], it is replaced by the string "symbol".
Example:

    Line: 2dPsdkljnfasf,dmfsa231!
    Destiny: /2/2d/2dP
    
    Line: !@afdsjlnasfkal;sdfads
    Destiny: /symbol/symbolsymbol/symbolsymbola

In Windows there are some folders/files that you can't create, so the files "con", "prn", "aux" and "nul" are going to be named:
"con-WindowsBannedWord", "prn-WindowsBannedWord", "aux-WindowsBannedWord", "nul-WindowsBannedWord".

# Install
Maybe you need NET Core 5.0 Runtime.
