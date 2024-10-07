# Exif Stripper
Super basic and does what the name implies, it strips Exif data from JPG images.

I needed an Exif stripper a while ago and couldn't find a good one that was easy to use on Mac so here we are.

## Compile
To compile, simply restore Nuget packages and run `dotnet build`

## Usage
The following command will strip all exif data from the images in the target folder and place them in `/stripped`

```bash
exifstripper <target_folder>
```

## Credits
- [Exif Library](https://github.com/oozcitak/exiflibrary) - The entire tool is based on this and uses this for exif 
manipulation.