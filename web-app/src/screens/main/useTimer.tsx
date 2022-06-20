import { useEffect, useState } from "react";

const oneSecond = 1000;
export const useTimer = () => {
    const [time, setTime] = useState<number>(0);
    const [intervalId, setIntervalId] = useState<NodeJS.Timer>();
    useEffect(() => {
        if (time === 0) {
            clearInterval(intervalId);
        }
    }, [time]);

    const resetTimerIfStarted = (seconds: number) => {
        if (intervalId != null) {
            clearInterval(intervalId);
        }
        setTime(seconds);
    };

    const secondTick = () => {
        setTime(time => time - 1);
    };

    const start = (millisecons: number) => {
        const seconds = roundMilliseconsToSeconds(millisecons);
        resetTimerIfStarted(seconds);

        const interval = setInterval(secondTick, oneSecond);
        setIntervalId(interval);
    };

    return {
        start,
        time
    };
};

const roundMilliseconsToSeconds = (milliseconds: number) => {
    return Math.floor(milliseconds / oneSecond);
};