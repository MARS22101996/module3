﻿Feature: FilteringProducts
    In order to find disired products
    As a user of the website
    I want to get necessary products after filtering

@filtering
Scenario Outline:  Getting appropriate products after filtering  by brands if brand's products exist
    Given If brand's products exist I have entered brand  <brand> 
    When  I press search if necessary products exist
    Then  Get products if necessary products exist
Examples:
| brand     |
|testbrand_1|

@filtering
Scenario Outline:  Getting appropriate products after filtering  by brands if brand's products do not exist
    Given if brand's products do not exist I have entered brand  <brand>
    When  I press search if necessary products do not exist
    Then  Do not get products if necessary products do not exist
Examples:
| brand     |
|testbrand_2|

@filtering
Scenario Outline:  Getting appropriate products after filtering  by price if products with this price exist
    Given If products with this price exist I have entered min price <minprice> and max price <maxprice>
    When  I press search if necessary products exist
    Then  Get products if necessary products exist
Examples:
| minprice | maxprice |
|10        |100       |

@filtering
Scenario Outline:  Getting appropriate products after filtering  by price if products with this price do not exist
    Given If products with this price do not exist I have entered min price <minprice> and max price <maxprice>
    When  I press search if necessary products do not exist
    Then  Do not get products if necessary products do not exist
Examples:
| minprice | maxprice |
|101       |200       |

@filtering
Scenario Outline:  Getting appropriate products after filtering by name if products with this name exist
    Given If products with this name exist I have entered name <word> in the searchstring
    When  I press search if necessary products exist
    Then  Get products if necessary products exist
Examples:
| word   |
|testname|

@filtering
Scenario Outline:  Getting appropriate products after filtering  by name if products with this name do not exist
    Given If products with this name do not exist I have entered name <word> in the searchstring
    When  I press search if necessary products do not exist
    Then  Do not get products if necessary products do not exist
Examples:
| word      |
|unknownname|
