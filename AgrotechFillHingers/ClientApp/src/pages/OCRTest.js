import { Typography } from 'antd/es';
import React, { useState, useRef } from 'react';

import Tesseract from 'tesseract.js';
import preprocessImage from '../helpers/preprocess';

const { Text } = Typography;

const OCRTest = (props) => {

    const [image, setImage] = useState("");
    const [text, setText] = useState("");
    const canvasRef = useRef(null);
    const imageRef = useRef(null);

    const handleChange = (event) => {
        setImage(URL.createObjectURL(event.target.files[0]))
    }

    const handleClick = () => {

        const canvas = canvasRef.current;
        const ctx = canvas.getContext('2d');

        ctx.drawImage(imageRef.current, 0, 0);
        ctx.putImageData(preprocessImage(canvas), 0, 0);
        const dataUrl = canvas.toDataURL("image/jpeg");

        Tesseract.recognize(
            dataUrl, 'rus',
            {
                logger: m => console.log(m)
            }
        )
            .catch(err => {
                console.error(err);
            })
            .then(result => {
                console.log(result)

                // Get Confidence score
                let confidence = result.data.confidence

                // Get full output
                let text = result.data.text

                setText(text);
            })
    }

    return (
        <div className="App">
            <main className="App-main">
                <h3>Actual image uploaded</h3>
                <img
                    src={image} className="App-logo" alt="logo"
                    ref={imageRef}
                />
                <h3>Canvas</h3>
                <canvas ref={canvasRef} width={1000} height={1000}></canvas>
                <h3>Extracted text</h3>
                <Text> {text} </Text>
                <input type="file" onChange={handleChange} />
                <button onClick={handleClick} style={{ height: 50 }}>Convert to text</button>
            </main>
        </div>
    );
}

export default OCRTest;

