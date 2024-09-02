# PDFParser

**PDFParser** is a console application that processes PDF files containing images of movie tickets. It extracts relevant data from the tickets, normalizes the data across timezones, and organizes it for further use.

## Features

- 📁 PDF Parsing: Utilizes PDF Pig to read and extract text from PDF files containing images of movie tickets.
- 🎟️ Ticket Data Extraction: Automatically identifies and extracts ticket information, including the movie title, date, and time.
- 🌐 Timezone Normalization: Normalizes dates and times across different timezones based on the detected culture from the PDF content.
- 📄 Output Generation: Outputs the parsed ticket information into a structured format.

## Instructions

1. Place your PDF files containing movie tickets in the designated input directory. The pdf scans must match the format of the example tickets, and have selectable text.
2. Run the application to parse and process the files.
3. The parsed ticket information will be saved in the specified output format.

   
## Build the Project

Clone the repository:
```bash
git clone https://github.com/YourUsername/PDFParser.git
```

Navigate to the project directory:
```bash
cd PDFParser
```

Build the project:
```bash
dotnet build
```

Run the application:
```bash
dotnet run
```

## Technologies Used

- **PDF Pig** for reading and parsing PDF files.
- **.NET Core** for backend logic and data processing.


## Prerequisites

- **Windows OS**

- **.NET SDK 8.0** or later

## Future Enhancements

- 🚀 Multi-Language Support: Expand the application to support more languages and cultures.
- 📊 Enhanced Data Output: Provide additional output formats like JSON or CSV for easier data integration.

This application was developed to handle the specific task of extracting and normalizing movie ticket data from PDFs. While it focuses on a niche use case, its modular design allows for easy adaptation to similar tasks.

This application was developed as part of an assignment for a course led by Krystyna Ślusarczyk. While the course provided the foundational knowledge, the solution was independently developed based on the provided requirements.
