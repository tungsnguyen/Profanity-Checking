import React, { useState } from 'react';
import File from './File';
import fileService from '../services/files';
import Notification from '../components/Notification';

const UploadFile = () => {
    const [selectedFiles, setSelectedFiles] = useState([]);
    const [notification, setNotification] = useState(null);
    const [notificationType, setNotificationType] = useState(null);

    const handleFileChange = (event) => {
        setSelectedFiles(Object.values(event.target.files));
    };

    const handleFileUpload = async () => {
        if (selectedFiles.length > 0) {
            checkReturnedFiles(selectedFiles).then((failedFiles) => {
                if (failedFiles.length > 0) {
                    setNotification(
                        `Files ${failedFiles.substr(0, failedFiles.length - 2)} contains forbidden words or phrases`
                    );
                    setNotificationType('error');
                } else {
                    setNotification('All files are safe');
                    setNotificationType('success');
                }

                setTimeout(() => {
                    setNotification(null);
                    setNotificationType(null);
                }, 10000);
            });
        }
    };

    const checkReturnedFiles = async (selectedFiles) => {
        let failedFiles = '';

        for (const file of selectedFiles) {
            const result = await fileService.post(file);

            if (result === false) {
                failedFiles += `${file.name}; `;
            }
        }

        return failedFiles;
    };

    return (
        <div>
            <h1>Upload file for profanity check</h1>
            <Notification message={notification} className={notificationType} />
            <div>
                <input type="file" multiple onChange={handleFileChange} />
                <button onClick={handleFileUpload}>Upload</button>
            </div>
            {selectedFiles.map((file) => (
                <File key={file.name} file={file} />
            ))}
        </div>
    );
};

export default UploadFile;
