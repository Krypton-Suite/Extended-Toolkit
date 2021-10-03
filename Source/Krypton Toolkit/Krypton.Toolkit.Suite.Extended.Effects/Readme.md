<!-- Start Document Outline -->

* [FadeController](#fadecontroller)
	* [Things of note in the picture](#things-of-note-in-the-picture)
	* [Usage](#usage)
* [ToDo](#todo)

<!-- End Document Outline -->

# `FadeController`
![](FadeInandOut.gif)

## Things of note in the picture
- The Fade In is initiated from the Parent form
- A callback is used to then change the button text on FadeComplete
- The Fade out can be done either via a button call, or via attaching to the `OnClosing` event.
- Krypton theming

## Usage
- Everything is done via the static class `FadeController`

# ToDo
- Better documentation on the `speeds`
- Better documentation on the `FadeController` API's
