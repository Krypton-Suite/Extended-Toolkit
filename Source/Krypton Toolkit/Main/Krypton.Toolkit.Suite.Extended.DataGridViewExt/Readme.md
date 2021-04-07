# DataGridView
![](SingleAndMultiDetailViews.png)
## Things of note in the picture
- Drop Arrow indicating active Details view
- RowHeader indicating which is active (In case child view has similar header to master)
- Scroll bar for the Details view
- MultiView showing Tabs for each Child
- Krypton theming
## Usage
The default display (as above) shows a single Detail View at the top, and a Multi Detail View at the bottom.  
The "Launch List View" list button in the Title bar shows how to use custom Lists as a dataset and also custom columns.  
### Launch List View
![](LaunchListView.png)
- The List view form allows the themes to be changed across the application.
- Demonstrates the removal of the Details row headers
- Demonstrates the usage of a ExtColumn type
- Shows how to hide columns 
- How to implement the re-sortable single list
  - Mandy has 1 Item
  - Mark has 4

## Single Detail View
This allows a Master Detail view to be seen with very little code from the client side

## Multi Detail View
Places Child Detail views into tabs under each Master row.

# ToDO
- Deal with no Details for Master row
- Make the Details view height dynamic
- Add Max Height Design control for MaxHeight
- More Documentation
