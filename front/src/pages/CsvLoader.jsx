import React, { useState } from 'react';
import CSVReader from 'react-csv-reader';
import axios from 'axios';
import PageContainer from '../components/PageContainer';
import Table from '../components/Table/table';
import '../styles/form.scss'
import '../styles/csvLoader.scss'
import Select from '../components/select';

const CsvLoader = () => {
    const [fileData, setFileData] = useState(null);
    const [name,] = useState(localStorage.getItem('name'))
    const handleFileLoaded = (data) => {
        setFileData(data);
    };

    const handleFileUpload = () => {
        axios.post('/api/upload', { data: fileData })
            .then((response) => {
                // Handle the response from the backend
                console.log(response.data);
            })
            .catch((error) => {
                // Handle any errors
                console.error(error);
            });
    };
    const options = {
        header: true,
        preview: 5
    }
    return (
        <PageContainer name={name}>
            <div className='csv-loader'>
            <div className="form csv">
                <div className='form-section'>
                    <div className='formInput'>
                        <Select options={["Estudantes", "Professores", "Materias cursados"]} label={"Entitidade a criar"} name={"entity"} />
                    </div>
                </div>
                <div className='form-section'>
                    <CSVReader
                        onFileLoaded={handleFileLoaded}
                        cssClass='reader formInput'
                        label={'Escolher'}
                        cssLabelClass='file-label'
                        inputId='file-input'
                        name='file-input'
                        parserOptions={options} />
                    <div className='form-section'>
                        <div className='formInput'>
                            <input type={'submit'} value="Anexar" onClick={(e) => handleFileUpload()} />
                        </div>
                    </div>
                </div>
            </div>
            {fileData && <Table data={fileData} />}
            </div>
        </PageContainer>)
};

export default CsvLoader;
