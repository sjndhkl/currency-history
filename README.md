# currency-history

The project can be compiled and run in Visual Studio which has support for Asp.net core version 5.0. This project was build on Visual Studio for MacOS.

## Endpoint Structure
**https://{hostname}/api/v1/currency/history/{baseCurrency}/{targetCurrency}/{dates}**

## Input description:
**{dates}:** comma separated dates in format yyyy-MM-dd e.g. 2014-05-03,2019-03-21
**{baseCurrency} or {targetCurrency} :** three char representation of currency for exammple USD, AUD, NPR

## Example Request:
**https://{hostname}/api/v1/currency/history/USD/AUD/2014-05-03,2019-03-21**

Example Response:
```
{
  "max": {
    "value": 1.40182
    "date": "2019-03-21",
  },
  "max": {
    "value": 1.077932
    "date": "2014-05-03",
  },
  "avg": 1.239876
}
```
