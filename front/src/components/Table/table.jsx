

export default function Table({ data= [] }) 
{
    console.log(data);
    if (data.length > 0)
    {
        var columns = Object.keys(data[0]);
        var rows = data.map(row => columns.map(column => row[column]));
    return (
        <div className="table">
            <table>
                <thead>
                    <tr>
                    {columns.map(column => (
                        <th key={column}>{column}</th>))}
                    </tr>
                </thead>
                <tbody>
                    {rows.map((row, index) => (
                    <>
                    <tr key={index}>
                        {row.map((cell, index) => (
                        <td key={index}>{cell}</td>
                        ))}
                    </tr>
                    <div className="row-split"></div>
                    </>
                    ))}
                </tbody>
            </table>
        </div>
    )
    }
    else{
        return (
            <div>
                EMPTY
            </div>
        )
    }
}