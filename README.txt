Prerequisites:

If you wish to check the databse than download the sqlitebrowser at https://sqlitebrowser.org/dl/

For the testing purposes the SKUs in the DB are:

vase
big-mug
napkins-pack

Here you can access public collection in postman to test the api:
https://www.postman.com/iwokal/workspace/iwokal-test-data/overview

In my understanding of assigment description removing method should remove all items from cart with the same SKU, so that is how it's implemented
Get total takes into account multiplication of the discount required quantity, so if there is a discount for 2 mugs and we add 5 mugs into the cart we would get 2x Discounted price for 2x2 mugs plus one normal price for the last mug.

