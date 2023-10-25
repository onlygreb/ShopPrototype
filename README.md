# ShopPrototype

Use Unity 2021.3.2f1 version in order to open the project.

## Assets Used:
### https://seliel-the-shaper.itch.io/character-base
### https://assetstore.unity.com/packages/2d/free-2d-mega-pack-177430
### https://cupnooble.itch.io/sprout-lands-ui-pack
### https://shubibubi.itch.io/cozy-town

## Project Executable:
### https://github.com/onlygreb/ShopPrototype/blob/main/ShopPrototypeBuild.rar

## Prototype Summary:
In order to get the "Skin" system working I setted an animator for each part of the character (i.e: outfits, hairs and hats), I also created a script to handle those animators.
On the player's movement I used rigdbody velocity to make the player move, It's the best way to avoid collision bugs, to get the player's direction I used the Unity new Input system and the script gets vector2 direction following the player input.
I've created a state machine to handle when the player is shopping and when it's not, system that helps to add new features in future if needed, and also helps to handle the game better.
To open the shop I idetify when the player triggers an object next to the shop's door, and with the new Unity Input system I've added a function to the perform event when the player press the interact button.
On the UI I've used scrollview to show the items, and created a itemCard prefab that gets all needed reference from a ScriptableObject and set the card Icon and price, also calls the Equip, Sell and Buy functions of the current Item.
To catalog the items, I've created ScriptableObjects that contains the item Icon, price, type and Id, this data is used to tell what item is being bought, equipped and sold.
To give the shop a depth aspect I've created a script that handles the SpriteRenderer sorting oder, and used the player's position as reference.
The items of the player also has differente sorting orders, so the player can use an outfit and a hat at the same time.
