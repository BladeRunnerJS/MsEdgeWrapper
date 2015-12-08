# MsEdgeWrapper

Wrapper for Microsoft Edge that allows it to programmatically started and stopped like a normal process.

## Description

This allows tools like js-test-driver to be used to start and stop the browser, where js-test-driver is not able to start Universal Windows applications using _process-activation_, and where js-test-driver would assume that killing the process it created would also kill the browser.

## Usage

Just run `MsEdgeWrapper.exe`, and the Microsoft Edge will be started. Killing `MsEdgeWrapper.exe` will cause the browser to be stopped.
