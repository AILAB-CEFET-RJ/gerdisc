import { faArrowRight, faTrashCan } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Empty from "../Empty/empty";
import './table.scss'



export default function Table(
    { 
        data = [],
        emptyMessage = 'There are no items in the table',
        useOptions = false,
        deleteCallback = undefined,
        detailsCallback = undefined
    }) {

    if (data.length > 0) {
        var columns = Object.keys(data[0]);
        var rows = data.map(row => columns.map(column => row[column]));
        return (
            <div className="table">
                <table>
                    <thead>
                        <tr>
                            {columns.map(column => (
                                <th key={column}>{column}</th>))}
                            {useOptions && <th>Opções</th>}
                        </tr>
                    </thead>
                    <tbody>
                        {rows.map((row, index) => (
                            <>
                                <tr key={index}>
                                    {row.map((cell, index) => (
                                        <td data-label={columns[index]} key={index}>{cell}</td>
                                    ))}
                                    {
                                        useOptions && <td className="options" data-label={'Options'}>
                                            {deleteCallback && <FontAwesomeIcon className="option" icon={faTrashCan} color="#004AAD" height={"1rem"} width="1rem" onClick={() => deleteCallback(row[0])} />}
                                            {detailsCallback && <FontAwesomeIcon className="option" icon={faArrowRight} color="#004AAD" height={"1rem"} width="1rem" onClick={() => detailsCallback(row[0])} />}
                                        </td>
                                    }
                                </tr>
                            </>
                        ))}
                    </tbody>
                </table>
            </div>
        )
    }
    else {
        return (
            <Empty message={emptyMessage} />
        )
    }
}