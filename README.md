# EasyPersianNormalizer

`EasyPersianNormalizer` is persian text normalizer

---

## Table of Contents

1. [Overview](#1-overview)
2. [Key Features](#2-key-features)
3. [Installation](#3-installation)
4. [Example](#4-example)
5. [Contributing](#5-contributing)
6. [Frequently Asked Questions (FAQ)](#6-frequently-asked-questions-faq)
7. [License](#7-license)

---

1\. Overview
----------------

A `EasyPersianNormalizer` is persian text normalizer

---

2\. Key Features
----------------

### 1. **Trim**
- **Description**: Removes extra whitespace at the beginning and end of the text.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Helps in cleaning text input by removing leading and trailing spaces.

### 2. **Remove Diacritics**
- **Description**: Strips diacritical marks (like accents) from Persian characters.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Ensures that text is uniform for comparison and search, disregarding variations in diacritical marks.

### 3. **Convert Arabic Ye and Ke to Persian**
- **Description**: Converts Arabic "ی" and "ک" characters to their Persian equivalents.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Standardizes Persian and Arabic text for consistency.

### 4. **Change to Half Space**
- **Description**: Converts full-width spaces to half-width spaces, which is common in Persian writing for better readability.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Corrects the spacing between words for more natural text formatting.

### 5. **Remove More Dash**
- **Description**: Removes additional or incorrect dash characters from the text.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Ensures that dashes are used properly in the text.

### 6. **Remove More Dot**
- **Description**: Removes excess or incorrect dot characters from the text.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Ensures proper punctuation and readability.

### 7. **Convert English Quotes to Persian**
- **Description**: Converts English-style quotation marks (") to Persian-style quotation marks (either `“”` or `«»`).
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Standardizes the use of quotation marks for consistent formatting in Persian text.

### 8. **Remove Extra Marks**
- **Description**: Removes extra punctuation marks like `؟` and `!` from the text.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Cleans up text by removing unnecessary punctuation.

### 9. **Remove Keshide**
- **Description**: Converts stretched Persian characters (like "کشیده") back to normal characters.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Ensures consistent and clean text for processing.

### 10. **Remove Spacing and Line Breaks**
- **Description**: Removes unnecessary spaces and line breaks.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Cleans up the text by removing redundant line breaks and spaces.

### 11. **Outside-Inside Spacing**
- **Description**: Adjusts spacing inside and outside of parentheses, brackets, and other punctuation marks like `()`, `[]`, `{}`, `“”`, and `«»`.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Standardizes punctuation spacing for better readability and consistency.

### 12. **Remove Hexadecimal Symbols**
- **Description**: Removes invisible or special characters that may be encoded as hexadecimal symbols.
- **Type**: `bool`
- **Default**: `true`
- **Use Case**: Cleans up the text by removing non-visible or corrupt characters that might have been added due to encoding issues.

### 13. **Number Conversion**
- **Description**: Converts numbers between Persian and English formats.
- **Type**: `NumberConvertorType`
- **Default**: `NumberConvertorType.ToEnglish`
- **Possible Values**:
	- `ToPersian`: Converts numbers to Persian digits.
	- `ToEnglish`: Converts numbers to English digits.
	- `None`: Leaves numbers unchanged.
- **Use Case**: Provides flexibility in handling Persian and English number formats based on the application's needs.

---

3\. Installation
----------------

You can install the `EasyPersianNormalizer` package from NuGet Package Manager:

### NuGet Package Manager

bash

Copy code

`Install-Package EasyPersianNormalizer`

### .NET CLI

You can also use the .NET CLI to install the package:

bash

Copy code

`dotnet add package EasyPersianNormalizer`

Once installed, you can start using the `NormalizerText` classes in your application.


---

4\. Example
----------------

```csharp
var yourText = "این متن من است";

var result = yourText.NormalizerText();
var result1 = yourText.NormalizerText(new NormalizerConfig());
```

---

5\. Contributing
----------------

We welcome contributions to the `EasyPersianNormalizer` project! If you'd like to contribute, please fork the repository and submit a pull request with your proposed changes.

### Steps to Contribute

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Implement your changes, ensuring that all unit tests pass.
4. Submit a pull request for review.

---

6\. Frequently Asked Questions (FAQ)
------------------------------------

**Q1: Can I use `EasyPersianNormalizer` in a highly concurrent environment?**

* yes you can

**Q2: What is the best use case for a `EasyPersianNormalizer`?**

* you can use it to save name of product on db storage and also for search on your website

---

7\. License
------------

This project is licensed under the MIT License. See the LICENSE file for more details.  
Feel free to modify or use it as part of your project
