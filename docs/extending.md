# AlphaUrsae Extending Guide

Extending the reference sample considers some planning and review subject to your current and future architecture.

## Example: Adding email
Using the reference solution, one realistic and common task would be to introduce email to the stack. 

Sending email is a common and tidies task, and therefor very few developers descide to implement SMTP services on their own. Instead they turn to `SendGrid`, `MailJet` or `Azure Communication Services` or similar to plan for email. 

The following example is a walkthrough of extending the architecture to allow email.

## Step 1 - external components
Per the product requirement, select a service to use for providing email. In this example, we stick with `SendGrid`. 

- First step is to add a new component to *Hosting* by adding a class library project named `AlphaUrsae.Hosting.SendGrid`.
- Find a Nuget to use. For this example, we will use the official [SendGrid nuget](https://www.nuget.org/packages/SendGrid).
- Implement a service binder, which enables our *Implementations* to consume the package.

## Step 2 - abstract the use case
By abstracting the use-case, you get to build a number of reusable methods and interfaces to allow *Applications* to leverage email distribution.

In this sample, we will be adding a class library project named `AlphaUrsae.Abstractions.Email` under *Abstractions*. Provide service interfaces and events to handle the SMTP distribution.

## Step 3 - bind the component
With the abstracts services and methods, it is time to bind all together.

- Add a project reference to any of the *Applications* project which require email, to the new `AlphaUrsae.Abstractions.Email` solution.
