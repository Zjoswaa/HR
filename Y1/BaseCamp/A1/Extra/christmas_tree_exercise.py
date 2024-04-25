"""
It's December and the city is in a Christmas mood. I have spent all my money on presents. I have no money left to buy a Christmas tree and decorate my house.
But since I know Python programming, I can make my own Christmas tree. Look how beautiful it is!

Do you think you can write the code to make one for yourself?

TIPS:
- Define a variable called height and receive an integer with input function. This will be the number of levels in your Christmas tree.
- Creat a function called xmas_tree that has one parameter which is the height of the tree.
- Use nested loops inside the function.
- Create base separately and add it at the end so you can make sure it will be in the middle no matter what the height of the tree is."""

"""
This one I made has a height of 20.

                   *
                  ***
                 *****
                *******
               *********
              ***********
             *************
            ***************
           *****************
          *******************
         *********************
        ***********************
       *************************
      ***************************
     *****************************
    *******************************
   *********************************
  ***********************************
 *************************************
***************************************
                 *****                    
                 *****                    
                 *****                    
                 *****                    
                 *****                    
                 *****                    
                 *****   

"""


def print_tree_for_loop(leaf_height=20, stem_height=7, stem_width=5):
    for i in range(leaf_height):
        if i != 0:
            print()
        for j in range(leaf_height - i - 1):
            print(" ", end="")
        for j in range(i + 1):
            print("*", end="")
        for j in range(i):
            print("*", end="")
    print()
    for i in range(stem_height):
        for j in range(int((leaf_height * 2 - 1) / 2) - int(stem_width / 2)):
            print(" ", end="")
        for j in range(stem_width):
            print("*", end="")
        if i != stem_height - 1:
            print()


def print_tree_while_loop(leaf_height=20, stem_height=7, stem_width=5):
    pass


print_tree_for_loop(20, 5, 5)
