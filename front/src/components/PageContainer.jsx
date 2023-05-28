import React from 'react';
import Footer from './footer';
import Header from './header';
import Spinner from './spinner';
import '../styles/form.scss';
import '../styles/pageContainer.scss';

export default function PageContainer({children, name, isLoading}){

    return (<div className="container">
        <main className="main">
            <div className="body">
                <Header name={name} />
                {!isLoading && children}
            </div>
            {isLoading && <Spinner/>}
                <Footer></Footer>
        </main>
        </div>
        )

}