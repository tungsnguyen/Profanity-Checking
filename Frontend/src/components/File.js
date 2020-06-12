import React from 'react';

const File = ({ file }) => {
    if (file) {
        return (
            <div>
                <h2>File Details:</h2>
                <p>File Name: {file.name}</p>
                <p>File Type: {file.type}</p>
                <p>
                    Last Modified:
                    {file.lastModifiedDate.toDateString()}
                </p>
            </div>
        );
    } else {
        return (
            <div>
                <br />
                <h4>Choose file before uploading</h4>
            </div>
        );
    }
};

export default File;
