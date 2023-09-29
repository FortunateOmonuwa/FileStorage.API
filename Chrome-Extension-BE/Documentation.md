# **API Documentation**

<summary>
This documentation provides an overview of the API endpoints and their functionality.
</summary>

## **FileModel**

<summary>
The FileModel are the files being uploaded into the application
</summary>

<details>

## **UploadFile**

- **ENDPOINT:** **POST** `/api/UploadFile`

### Headers

| Content-Type        | Value |
| ------------------- | ----- |
| multipart/form-data | File  |

- **Upload a file to the server**

##

**Input:**

- file (multipart/form-data)
  **Sample Request:**

```Query Params
POST Request URL = http://fortunate3d-001-site1.atempurl.com/api/UploadFile


Key: file
Value:Myvideo.mp4(file to upload)


```

##

if successful, returns:

**Status 200 OK: The file was successfully uploaded.**

**Sample Response:**

```Text

  File Myvideo.mp4 was successfully uploaded to wwwroot\Files\0743771a-ba18-43f9-9ff2-0915ad55494e.mp4 with a unique name of 0743771a-ba18-43f9-9ff2-0915ad55494e.mp4....

  File can be viewed on http://fortunate3d-001-site1.atempurl.com/api/DownloadFile?fileId=0743771a-ba18-43f9-9ff2-0915ad55494e.mp4

```

##

if invalid (e.g. due to file size greater than size limit ), returns:
**Status 400 Bad Request:**

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-52eaef32b671b3fb7bf2e06ea82351a8-3a552c38fd4b70bb-00",
  "errors": {
    "": [
      "Failed to read the request form. Multipart body length limit 55000000 exceeded."
    ]
  }
}
```

##

For extremely large files, returns:
**Status 413 Request entity too large**

```Text
  The page was not displayed because the request entity is too large.

```

##

## **Download File**

- **ENDPOINT:** **GET** `/api/DownloadFile`

### Headers

| Content-Type | Value  |
| ------------ | ------ |
| File         | fileId |

- **Download a specific file from the server.**
  ##
  **Input:**
- Query parameter fileId (string) - The identifier of the file to download (can be file ID, file path, or unique name.).

**Sample Request:**

```Query Params
GET Request URL = http://fortunate3d-001-site1.atempurl.com/api/DownloadFile?fileId=82c6b3b0-245b-4e0f-ba22-e56b726546b9.mp4


Key: fileId
Value:82c6b3b0-245b-4e0f-ba22-e56b726546b9.mp4 //using the unique name


```

##

if successful, returns:

**Status 200 OK and returns the file**

##

if invalid (e.g. due to invalid query parameter ), returns:
**Status 400 Bad Request:**

```Text(Pretty)
Error File with Id: {queryparam} does not  exist.Please try again
Chrome-Extension-BE



Error
File with Id: {queryparam} does not exist.Please try again
Chrome-Extension-BE
```

</details>
