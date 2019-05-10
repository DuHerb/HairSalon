# HairSalon.Solution

#### This is an mvc project app for epicodus utilizing basic a database

### Version 1.0 --- 5/10/2019

### Author: Dustin Herboldshimer

## Description

This mvc project is a basic model of a HairSalon employee database.  Users
will be able to create stylists and customers, and then view stylists and their
unique customers.

## Setup/Installation Requirements

1.  download HairSalon.Solution into your local environment
2.  In mysql: CREATE DATABASE dustin_herboldshimer
3.  In phpmyadmin: import dustin_herboldshimer.sql (located in HairSalon.Solultion/DBbackups)
4.  In terminal: HairSalon.Solution$ cd HairSalon; dotnet restore; dotnet run
5.  View/Use app in browser at localhost:5000

## Application Specifications

| Behavior              | Input/Action                                                                                                  | Expected Result                                                         |
|-----------------------|---------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------|
| Create New Stylist    | /hairsalon/newstylist </br>  Stylist Name: "Frank" (userInput)</br> Create Stylist(button) => (on-click)</br> | /hairsalon/stylist/1</br> "Frank"                                       |
|  View All Stylists    | /hairsalon</br> See All Stylists(button) => (on-click)                                                        | /hairsalon/stylist/index</br> "Frank"</br> "Steph"</br> "Ed"            |
| View Specific Stylist | /hairsalon/index</br> "Frank"(index link) => (on-click)                                                       | /hairsalon/stylist/1</br> "Name: Frank"</br> "Customers:"</br> ...</br> |
| Create New Customer   | /hairsalon/stylist/1/newcustomer</br> New Customer Name: "Teddy"</br> Create Customer(button) => (on-click)   | /hairsalon/stylist/1/customer/1</br> "Name: Teddy"</br>"Stylist: Frank" |
| View All Customers    | /hairsalon</br> View All Customers(button) => (onclick)                                                       | /hairsalon/customer/index</br> "Teddy"</br> "Jennifer"</br>"Veronica"   |

## Support and contact details

Contact Dustin Herboldshimer at dustnpdx@gmail.com

## Technologies Used

1. Asp.Net.Core 2.2
2. Mysql

### License

Protected under the <a href="https://opensource.org/licenses/MIT">MIT License</a>

Copyright (c) 2019 **Dustin Herboldshimer**