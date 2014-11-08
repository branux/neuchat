NeuChat
=======

## Overview

This presentation application demonstrates core fundementals of Xamarin Forms development.  It combines Azure Mobile Services, SignalR, Xamarin Forms Multi-Client Native and MVVM solution architecture.

The presentation is designed to give a practical hands on tutorial to learn far beyond a Hello, World and gain deeper understanding of "how" to accomplish common application solutions.

---

#### Module Steps

---

#### 1] Create new Azure Mobile Services Project
- .NET Backend through Azure Portal
- Download starter serverside project

---

#### 2] Add/Update additional NUGET packages

- WindowsAzure.MobileServices.Backend
- WindowsAzure.MobileServices.Backend.Tables
- WindowsAzure.MobileServices.Backend.Entities
- WindowsAzure.MobileServices.Backend.SignalR

---

#### 3] Remove template generated objects

- DataObjects.TodoItem 
- DbSet<TodoItem> in neuContext
- TodoItemController
- Seed initializer for sample TodoItem models

---

#### 4] Add SignalR basics to backend

- WebApiConfig changes
- Create a hub
- Publish to Azure (from step 1)

---

#### 5] Create Xamarin Forms PCL project

- Update Solution NUGET packages for updated Forms and Platform packages

---

#### 6] Add MVVM Light for Solution Architecture

- Add ViewModelLocator
- Add Bootstrappers to each platform
- Add draft main UI page in XAML

---

#### 7] Initial Databinding and local messaging

- Pub/Sub with MessagingCenter
- Databind ListView -> ObservableCollection
- ListView DataTemplate ViewCell
- RelayCommand implementation

---

#### 8] Adding Azure Mobile Services

- Add Xamarin Components per platform
- Initialize azure mobile services per platform

---

#### 9] Adding Google Login and Logout

- Create Google API Console project (web app)
- Create OAUTH for Google project
- Configure Azure Mobile Service Identity provider
- Implement platform injection for Login and Logout
- Adding Login application logic
 - Platform weirdness
- Adding Logout application logic
 - Azure and Cookie platform injection

---

#### 10.a] Updating Azure SignalR backend

- Updating the hub implementation
- Adding Authorization
- Publish new AMS backend

---

#### 10.b] Updating mobile clients to connect to SignalR

- Add SignalR components/nuget (for winphone and shared pcl)
- Add hub connection service
- Add hub initialization to OnAppearing for main view

#### 11] Adding some flair

- Add app icon (Android and WP)
- Add a better looking and handling login page