import {Multiselect as Multi} from 'multiselect-react-dropdown';
import Spinner from "./spinner"



export default function MultiSelect(
    {
        options,
        onSelect,
        onRemove,
        placeholder,
        isLoading,
        displayValue
    }
) {
    return <div id="multiselect">
    <Multi
        options={options} // Options to display in the dropdown
        closeOnSelect={false}
        loading={isLoading}
        loadingMessage={<Spinner />}
        placeholder={placeholder}
        onSelect={onSelect} // Function will trigger on select event
        onRemove={onRemove} // Function will trigger on remove event
        displayValue={displayValue} // Property name to display in the dropdown options
        style={{
            chips: {
                background: '#004AAD',
                color: '#004AAD'
            },
            multiselectContainer: {
                display: 'flex',
                flex: 1,
                color: '#004AAD',
                width: '100%',
                height: '100%'
            },
            searchBox: {
                border: '1px solid #004AAD',
                borderRadius: '1rem',
                color: '#004AAD',
                width: '100%',
                flex: 1,
                fontSize: 'medium',
                margin: '.5rem'
            }
        }}
    />
    </div>
}