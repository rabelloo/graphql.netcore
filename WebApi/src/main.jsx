import React from 'react';
import ReactDOM from 'react-dom';
import GraphiQL from 'graphiql';
import fetch from 'isomorphic-fetch';
import 'graphiql/graphiql.css';
import './styles.css';

function graphQLFetcher(graphQLParams) {
    return fetch(window.location.origin, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(graphQLParams)
    }).then(response => response.json());
}

ReactDOM.render(
    <GraphiQL fetcher={graphQLFetcher}/>,
    document.getElementById('root')
);
