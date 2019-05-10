# HairSalon.Solution

#### This is an mvc project app for epicodus utilizing basic a database

### Version 1.0 --- 5/10/2019

### Author: Dustin Herboldshimer

## Description

This mvc project is a basic model of a HairSalon employee database.  Users
will be able to create stylists and customers, and then view stylists and their
unique customers.

## Setup/Installation Requirements

| Behavior              | Input/Action                                                                                 | Expected Result                                                 |
|-----------------------|----------------------------------------------------------------------------------------------|-----------------------------------------------------------------|
| Create New Stylist    | /hairsalon/newstylist  
Stylist Name: "Frank" (userInput) Create Stylist(button) => (on-click) |  /hairsalon/stylist/1  
"Frank"                                   |
|  View All Stylists    |  /hairsalon  
See All Stylists(button) => (on-click)                                          |  /hairsalon/stylist/index  
"Frank" "Steph" "Ed"                  |
| View Specific Stylist |  hairsalon/index  
"Frank"(index link) => (on-click)                                          |  /hairsalon/stylist/1  
"Name: Frank" "Customers:" ... ... ...    |
| Create New Customer   |  ..stylist/1/newcustomer  
New Customer Name: "Teddy" Create Customer(button) => (on-click)    |  /hairsalon/stylist/1/customer/1  
"Name: Teddy" "Stylist: Frank" |
| View All Customers    |   /hairsalon  
View All Customers(button) => (onclick)                                         |  /hairsalon/customer/index  
"Teddy" "Jennifer" "Veronica"        |

## Application Specifications

## Support and contact details

Contact Dustin Herboldshimer at dustnpdx@gmail.com

## Technologies Used

1. Asp.Net.Core 2.2
2. Mysql

### License

Protected under the <a href="https://opensource.org/licenses/MIT">MIT License</a>

Copyright (c) 2019 **Dustin Herboldshimer**