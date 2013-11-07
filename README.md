#GUI-ffmpeg

Graphical interface for ffmpeg writed in C#. Provide *simple* way to use ffmpeg for various *simple* tasks.

##Introduction

Please keep in mind that I first made this application for personnal need and begun to add functionnalities for friends. It's working but some bugs may appear because I haven't the time to test everything. Feel free to yell at me :)

All codecs aren't supported because I haden't the time to enum all of them in code. I will add more later or you can do it by simply add fields to AudioEncoding or VideoEncoding enums with the apropriates attributes.

All option of ffmpeg are not included in the CommandLineBuilder class but you can easily add unlisted parameters via AddRaw() function.

The source code is divided into 3 parts :

1. Core-ffmpeg : librairy with enums, structures, basic UI, a command line builder, etc
2. GUI-ffmpeg : main executable
3. Setup if you like install it this way

##Installation

First, you must download ffmpeg and ffprobe binaries for Windows and put them into **lib** folder. They will be copied into the output folder at compilation time.

They can be downloaded from [http://ffmpeg.zeranoe.com/builds/] [1] (link grabbed from official ffmpeg download page).

Then, just compile :)

For the moment, 5 'shortcuts' are available when launching the aplication.

##Remove Sound

Use this in order to remove sound from a media file.
Source file and destination file will be asked. Video codec will be copied and sound removed.

##Extract MP3

Grab audio from input file and save it to MP3 encoded file (Bitrate 128k, SR 44.1k).

##Concatenate

This part allow you to concatenate up to 3 media files under those conditions :

1. input files MUST be the same type. Either video+audio or audio only or video only.
2. if video is used, all videos MUST have the same resolution
3. you MUST apply re-encode. Parameters will be asked to you after input validation

Concat mode (video+audio or audio only or video only) is always dicted by the first file.
After validation, the re-encode scren will pop. Set your output parameters, validate and you will be ask the output file.

##GUI

This part is a little complex to explain because it was first design to suit a personal need.
Anyway it allows you to process multiple media files with different parameters at once.

You just have to drag/drop files on the upper part of the form and set parameters.
You can : re-encode (mp4/webm/flv/mp3), resize, rotate, apply overlays, generate thumbnails, etc

Output files are prefixed with **__enc__** and suffixed with the extension corresponding to output format.

More information in README.html but it's in french ... sorry

##File re-encode

A simple one file re-encode form.
Just select your input and output files, specify re-encode parameter and here it goes.

##Conclusion
This is amateur software so be kind but feel free of any remarks :)

  [1]: http://ffmpeg.zeranoe.com/builds/