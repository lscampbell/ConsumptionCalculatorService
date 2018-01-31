import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export default class RawConsumption extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <div className="row">
                <div className='col-sm-11'>
                    <h1>Consumption Uploaded Topic</h1>
                    <p>This is mapped to live uploaded consumption entering system: </p>
                </div>
                <div className='col-sm-1'>
                    <button id="rawSendButton">Start</button>
                </div>
            </div>
            <div className="row">
                <div className='col-sm-12'>
                    <table className='table' id='rawConsumption'>
                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>StartTime</th>
                                <th>EndTime</th>
                                <th>Mpan</th>
                                <th>SupplyPointRef</th>
                                <th>Kwh</th>
                                <th>Lag</th>
                                <th>Lead</th>
                                <th>Estimated</th>
                            </tr>
                        </thead>
                        <tbody>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>;
    }
}