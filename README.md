# Checkout.com Payment Gateway .Net Challenge

Thank you for the opportunity to handle this code challenge. 
Before we get started, I am very well aware that this small asp.net core 3.1 web api project is NOT a match for a fully production ready payment gateway and it lacks the consideration around 

- `Failure Retrial Policies`
- `Scalable data storage`
- `Multiple Bank integration and different protocol requirements`
- `Fully auditable transaction events`
- `Tokenised card payment and digital wallets etc`
- `Multiple currency support and fee calculation`


## Introduction

The solution is built using Visual Studio Professional 2019 Version 16.9.4

The gateway supports only GBP currency


## API Details

It supports two operations

**Request a card payment**

HTTP POST : http://localhost:5000/payments

Request Headers :

- Content-Type : application/json
- Authorisation: `test_key1`

Payload:
```json
{
    "expirymonth": 9,
    "expiryyear" : 2022,
    "number" : "1234 5678 9012 3452",
    "amount" : 111,
    "cvv" : "123",
    "currencycode": "GBP",
    "name" : "Mr Test"
}
```

Example Response:


```json
{
    "id": "17e15e5b-edc1-4bb0-bce8-12a258004dc0",
    "success": true,
    "status": "fulfilled",
    "amount": 111,
    "currency": "GBP",
    "processedOn": "2021-05-13T13:56:06.9092883Z",
    "bankReference": "290e11c6-363f-4807-90c6-1bcca80730c4"
}
```

It returns the following Http status codes for various conditions

- 200 : For a successful response
- 401 : If the Authorisation header is not specified OR it is other than `test_key1`
- 400 : In case of request validation fails e.g. expiry month is not specified or outside the range of 1 and 12


**Get card payment details**

HTTP GET : http://localhost:5000/payments/17e15e5b-edc1-4bb0-bce8-12a258004dc0

Request Headers :

- Content-Type : application/json
- Authorisation: test_key1

Example Response:

```json
{
    "id": "17e15e5b-edc1-4bb0-bce8-12a258004dc0",
    "cardDetail": {
        "number": "************3452",
        "expiryMonth": 9,
        "expiryYear": 2022,
        "currencyCode": "GBP",
        "name": "Mr Test"
    },
    "amount": 111,
    "merchantReference": null,
    "merchantId": "M_1111",
    "success": true,
    "status": "fulfilled",
    "bankReference": "290e11c6-363f-4807-90c6-1bcca80730c4",
    "bankDetails": "authorised",
    "requestedOn": "2021-05-13T13:56:06.9071733Z",
    "processedOn": "2021-05-13T13:56:06.9092883Z"
}
```

## docker 

The Dockerfile to build the api container image is located in `Checkout.PaymentGateway.Api` project folder



