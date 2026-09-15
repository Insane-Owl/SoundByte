## Purpose
SoundByte is a clean desktop soundboard application that allows users to manage and play audio clips via tiles or custom hotkeys.

## Application Background
This project serves as the GUI design phase for my approved final project, substituting a standard console application. It focuses on the front-end user interface and layout.

## How to Run
1. Clone the repo to your local machine.
2. Open the `SoundByte.slnx` file in Visual Studio.
3. Click "Start" to run the application.

## How to Use the Interface
**Navitation:** Use the top toolbar to access the master volume and global actions.
**Adding Sound Tiles:** Click the "New Sound" Button in the toolbar to add a new tile.
**Editing:** Click the ellipses (⋯) button on and sound tile to open its properties in the right sidebar.
**Clearing/Deleting:** Use the "Delete" button in the sidebar to remove its tile and clear the form.
**Closing:** Click the Exit button to close the application.

## Controls & Events Implemented
**Controls Used:**
* `Form` and `Panel` controls for layout structure.
* `TableLayoutPanel` and `FlowLayoutPanel` for responsive window resizing.
* Custom-built `UserControl` (SoundTile) which populates the main grid.
* `Label` controls for labeling, `Button` for buttons, `TextBox` for input, and `TrackBar` for volume.

**Events Implemented:**
* `Click`: Used for the Save, Delete, Exit, Edit, Close Editor, and New Sound buttons to trigger mock actions and UI updates.
* `Paint`: Used to draw a thin border around the custom SoundTile controls.
* `ValueChanged`: Used for the TrackBar volume bars to update their percentage labels.
* `EventHandler`: Custom events used to pass data from the `SoundTile` controls to the main form (such as to populate the editor).

## Validation Included
The application validates that user input exists in the editor sidebar before allowing a mock save. It verifies that `Clip Name` and `File Path` are not empty or whitespace. If validation fails, saving is cancelled, an error is displayed in the status bar, and focus is pulled to the input that failed validation.

## Known Limitations
As this is currently the GUI development phase, there is no backend to connect yet, so most buttons that do anything simply trigger mock functions. Playing audio, saving files to the disk, loading files from the disk, assigning hotkeys, etc. are not yet implemented.
